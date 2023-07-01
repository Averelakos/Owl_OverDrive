import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { FileParameter } from 'src/app/data/types/image/file-parameter';


@Injectable({
  providedIn: 'root'
})
export class ImageService{
    key: string = 'ImagesDraft'
    baseUrl = environment.apiUrl + this.key;
    constructor(private http: HttpClient){}

    uploadImages(image?: FileParameter| undefined) {
       const content_ = new FormData();

       if(image === null || image === undefined) {
        throw new Error("The parameter 'image' cannot be null.")
       }
       else {
        content_.append("image", image.data, image.fileName ? image.fileName : 'image')
       }

       let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        }

        return this.http.post<any>(this.baseUrl + '/UploadImage', content_)
    }
}