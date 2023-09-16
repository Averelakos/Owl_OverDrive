import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-game-pagination',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-pagination.component.html',
  styleUrls: ['./game-pagination.component.scss']
})
export class GamePaginationComponent implements AfterViewInit {
  @ViewChild('gamePagination') paginationElement: ElementRef
  @Input() pages: number = 25
  @Input() currentPage: number = 1
  @Output() selectedPage = new EventEmitter<number>
  constructor(public renderer: Renderer2){}
  ngAfterViewInit(): void {
    this.createPagination(this.pages,this.currentPage)
  }

  createPagination(pages, page){
    this.selectedPage.emit(page)
    // Remove list if already exists to add the new one
    const childElement = this.paginationElement.nativeElement.children
    if (childElement != null && childElement != undefined && childElement.length > 0) {
      this.renderer.removeChild(this.paginationElement.nativeElement, childElement[0])
    }

    let listElement = this.renderer.createElement('ul')
    let active
    let pageCutLow = page - 1
    let pageCutHigh = page + 1
    //  Show the Previous button only if you are on a page other than the first
    if(page > 1) {
      // str += '<li class="page-item previous no"><a onclick="createPagination(pages, '+(page-1)+')">Previous</a></li>';
      const previousElement = this.renderer.createElement('li')
      const previousButton = this.renderer.createElement('a')
      const newText = this.renderer.createText('Previous')
      previousButton.append(newText)

      this.renderer.listen(previousButton, 'click', () =>{
        this.createPagination(pages, page-1)
      })

      this.renderer.appendChild(previousElement, previousButton)

     this.renderer.appendChild(listElement, previousElement)

    }

    // Show all the pagination elements if there are less than 6 pages total
    if (pages < 6) {
      for (let p = 1; p <= pages; p++) {
        active = page == p ? "active" : "no";
        const listItem = this.renderer.createElement('li')
        this.renderer.addClass(listItem,  active)
        const button = this.renderer.createElement('a')
        this.renderer.listen(button, 'click', () =>{
          this.createPagination(pages, p)
        })
        const newText = this.renderer.createText(p.toString())
        button.append(newText)
        this.renderer.appendChild(listItem, button)
        this.renderer.appendChild(listElement, listItem)
      }
    }
    else {
      // Use "..." to collapse pages outside of a certain range
      // Show the very first page followed by a "..." at the beginning of the
      // pagination section (after the Previous button)
      if (page > 2) {
        const listItem = this.renderer.createElement('li')
        this.renderer.addClass(listItem,  'no')
        this.renderer.addClass(listItem,  'page-item')
        const button = this.renderer.createElement('a')
        this.renderer.listen(button, 'click', () =>{
          this.createPagination(pages, 1)
        })
        const newText = this.renderer.createText('1')
        button.append(newText)
        this.renderer.appendChild(listItem, button)
        this.renderer.appendChild(listElement, listItem)
        
        if (page > 3) {
          const listItem = this.renderer.createElement('li')
          this.renderer.addClass(listItem,  'out-of-range')
          const button = this.renderer.createElement('a')
          this.renderer.listen(button, 'click', () =>{
            this.createPagination(pages, page-2)
          })
          const newText = this.renderer.createText('...')
          button.append(newText)
          this.renderer.appendChild(listItem, button)
          this.renderer.appendChild(listElement, listItem)
        }

      }

      // Determine how many pages to show after the current page index
      if (page === 1) {
        pageCutHigh += 2;
      } else if (page === 2) {
        pageCutHigh += 1;
      }
      // Determine how many pages to show before the current page index
      if (page === pages) {
        pageCutLow -= 2;
      } else if (page === pages-1) {
        pageCutLow -= 1;
      }

      // Output the indexes for pages that fall inside the range of pageCutLow
      // and pageCutHigh
      for (let p = pageCutLow; p <= pageCutHigh; p++) {
        if (p === 0) {
          p += 1;
        }
        if (p > pages) {
          continue
        }
        active = page == p ? "active" : "no";
        const listItem = this.renderer.createElement('li')
        this.renderer.addClass(listItem,  active)
        const button = this.renderer.createElement('a')
        this.renderer.listen(button, 'click', () =>{
          this.createPagination(pages, p)
        })
        const newText = this.renderer.createText(p.toString())
        button.append(newText)
        this.renderer.appendChild(listItem, button)
        this.renderer.appendChild(listElement, listItem)
      }

      // Show the very last page preceded by a "..." at the end of the pagination
      // section (before the Next button)
      if (page < pages-1) {
        if (page < pages-2) {
          const listItem = this.renderer.createElement('li')
          this.renderer.addClass(listItem,  'out-of-range')
          const button = this.renderer.createElement('a')
          this.renderer.listen(button, 'click', () =>{
            this.createPagination(pages, page+2)
          })
          const newText = this.renderer.createText('...')
          button.append(newText)
          this.renderer.appendChild(listItem, button)
          this.renderer.appendChild(listElement, listItem)
        }
        const listItem = this.renderer.createElement('li')
        this.renderer.addClass(listItem,  'page-item')
        this.renderer.addClass(listItem,  'no')
        const button = this.renderer.createElement('a')
        this.renderer.listen(button, 'click', () =>{
          this.createPagination(pages, pages)
        })
        const newText = this.renderer.createText(pages)
        button.append(newText)
        this.renderer.appendChild(listItem, button)
        this.renderer.appendChild(listElement, listItem)
        
      }
    }

    // Show the Next button only if you are on a page other than the last
    if (page < pages) {
      const listItem = this.renderer.createElement('li')
      this.renderer.addClass(listItem,  'page-item')
      this.renderer.addClass(listItem,  'next')
      this.renderer.addClass(listItem,  'no')
      const button = this.renderer.createElement('a')
        this.renderer.listen(button, 'click', () =>{
          this.createPagination(pages, page+1)
        })
      const newText = this.renderer.createText('Next')
      button.append(newText)
      this.renderer.appendChild(listItem, button)
      this.renderer.appendChild(listElement, listItem)
    }
    
    // Return the pagination string to be outputted in the pug templates
    this.renderer.appendChild(this.paginationElement.nativeElement, listElement)
  }
}
