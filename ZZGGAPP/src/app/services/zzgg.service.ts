import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Account } from '../models/account';
import { LoLVersion } from '../models/lolVersion';
import { ImageUrl } from '../models/imageUrl';

@Injectable({
  providedIn: 'root'
})
export class ZzggService {

  constructor(private http: HttpClient) { }

  lolRootURL = 'https://localhost:7135/ZZGG/';

  dragonRootUrl = 'https://ddragon.leagueoflegends.com/'


getVersion()
: Observable<LoLVersion>{
  const url = this.lolRootURL.concat("GetVersion");
  return this.http.get<LoLVersion>(url,{})
}

getAccountByName(name: string | null ="")
  : Observable<Account>{
    const url = this.lolRootURL.concat("GetAccountDetailsBySummonersName?summonerName="+name);
    return this.http.get<Account>(url,{})
  }

  getIcon(iconId: number| undefined)
  : Observable<ImageUrl>{
    const url = this.lolRootURL.concat("GetIconByVersionAndIconId?iconId="+iconId);
    return this.http.get<ImageUrl>(url,{})
  }

}
