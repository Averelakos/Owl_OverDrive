import { AfterViewInit, Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-birthdate-selectors',
  templateUrl: './birthdate-selectors.component.html',
  styleUrls: ['./birthdate-selectors.component.scss']
})
export class BirthdateSelectorsComponent implements AfterViewInit{
  

  @Input() parentFormGroup:FormGroup
  months:Array<string> = ['January', 'February', 'March', 'April','May', 'June', 'July', 
  'August', 'September', 'October','November', 'December'];
  years:Array<string> = [];
  days:Array<string> = [];


  /**
   * References to drop down menu of the date of birth
   */
  monthSelect:string;
  daySelect:number;
  yearSelect:number;

  ngAfterViewInit(): void {
    this.populateYears();
  }

  onMonthValueChange(e) {
    this.populateDays(e)
  }

  raiseError() {
    return (this.parentFormGroup.get('dateOfBirth.year')?.touched 
    && this.parentFormGroup.get('dateOfBirth.year')?.hasError('required') 
    && this.parentFormGroup.get('dateOfBirth.month')?.touched 
    && this.parentFormGroup.get('dateOfBirth.month')?.hasError('required') 
    && this.parentFormGroup.get('dateOfBirth.day')?.touched 
    && this.parentFormGroup.get('dateOfBirth.day')?.hasError('required'));
  }
  /**
   * Based of the user month choose
   * fill the day select with the amount
   * of days for that particular month
   * @param month choosen month
   */
  populateDays(month) {
    
    //Holds the number of days in the month
    let dayNum;
    //Get the current year
    let year = this.yearSelect;


    if(month === 'January' || month === 'March' || month === 'May' || month === 'July' || month === 'August' || month === 'October' || month === 'December') {
        dayNum = 31;
    } else if(month === 'April' || month === 'June' || month === 'September' || month === 'November') {
        dayNum = 30;
    }else{
        //Check for a leap year
        if(new Date(year, 1, 29).getMonth() === 1){
            dayNum = 29;
        }else{
            dayNum = 28;
        }
    }

    //Insert the correct days into the day <select>
    for(let i = 1; i <= dayNum; i++){
      this.days.push((i).toString());
    }

  }

  /**
   * Create and add the options 
   * for the year select field in the html file
   */
  populateYears(){
    //Get the current year as a number
    let year = new Date().getFullYear();
    //Make the previous 100 years be an option
    for(let i = -1; i < 101; i++){
      let option = (year - i).toString();
      this.years.push(option);
    }
  }
}
