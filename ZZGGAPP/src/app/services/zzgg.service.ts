import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Account } from '../models/account';
import { LoLVersion } from '../models/lolVersion';
import { ImageUrl } from '../models/imageUrl';
import { TotalMasteryScore } from '../models/totalMasteryScore';
import { AccountChampionStats } from '../models/accountChampionStats';
import { Champion } from '../models/champion';
import { ApiResponse } from '../models/generalModels/apiResponse';

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

getAccountByName(name: string | null = "")
  : Observable<ApiResponse<Account>>{
    const url = this.lolRootURL.concat("GetAccountDetailsBySummonersName?summonerName="+name);
    return this.http.get<ApiResponse<Account>>(url,{})
  }

  getIcon(iconId: number| undefined)
  : Observable<ImageUrl>{
    const url = this.lolRootURL.concat("GetIconByVersionAndIconId?iconId="+iconId);
    return this.http.get<ImageUrl>(url,{})
  }

  getTotalChampionMasteryScoreBySummonerId(summonerId: string | null = "")
  : Observable<TotalMasteryScore>{
    const url = this.lolRootURL.concat("GetAccountTotalMasteryLevel?summonerId="+summonerId);
    return this.http.get<TotalMasteryScore>(url,{})
  }
  
  getAllChampionScoreBySummonerId(summonerId: string | null = "")
  : Observable<Array<AccountChampionStats>>{
    const url = this.lolRootURL.concat("GetAllChampionScoreBySummonerId?summonerId="+summonerId);
    return this.http.get<Array<AccountChampionStats>>(url,{})
  }

  getChampionById(championId: number | undefined)
  : Observable<Champion>{
    const url = this.lolRootURL.concat("GetChampionById?championId="+championId);
    return this.http.get<Champion>(url,{})
  }

}
