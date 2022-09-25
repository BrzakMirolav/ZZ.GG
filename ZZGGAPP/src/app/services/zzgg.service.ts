import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ZzggService {

  constructor(private http: HttpClient) { }

  rootURL = 'https://localhost:7135/ZZGG/';

  //rootURL = 'https://ddragon.leagueoflegends.com/cdn/12.18.1/img/profileicon/4791.png'
  icon = 4791;

 /* getIcon() {
    this.http.get(this.rootURL + 'GetIconByVersionAndIconId?iconId=4791').subscribe(data=>{
      this.icon = data.toString();
      });
     return this.icon;
  }*/

  /*getIcon(): Observable<HttpResponse<string>> {
    return this.http.get<string>(
      this.rootURL + 'GetIconByVersionAndIconId?iconId=4791', { observe: 'response' });
      //this.rootURL + '4791.png', { observe: 'response' });
      
  }*/

  public getIcon(): Observable<string> {
    const url = this.rootURL + 'GetIconByVersionAndIconId'
    let queryParams = new HttpParams();
    queryParams = queryParams.append("iconId",this.icon);
    return this.http.get<string>(url,{params:queryParams});
}
  /*getIcon(){
    let url = this.rootURL+ 'GetIconByVersionAndIconId?iconId=4791';
    let response = this.http.get(url);
    console.log(response);
    return response;
  }*/

}
