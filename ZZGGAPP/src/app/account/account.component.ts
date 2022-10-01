import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Account } from '../models/account';
import { faSearch, faRefresh } from '@fortawesome/free-solid-svg-icons';
import { ZzggService } from '../services/zzgg.service';
import { AccountChampionStats } from '../models/accountChampionStats';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  faSearch = faSearch;
  faRefresh = faRefresh;
  constructor(private zzggService: ZzggService) {
    
   }
   version: string | null = "";
   errors: string | null = "";
   account: Account | undefined;
   icon: string | null ="";
   accountLoaded: boolean = false;
   score: number | undefined;
   championsByAcc: Array<AccountChampionStats> | undefined;
   championIcon: string | null = "";
   
  
  ngOnInit(): void {
    this.getAccountByName("raben"); 
    this.getVersion();
  }

  searchAccount(){
    var userName = ((document.getElementById("userNameSearchInput") as HTMLInputElement).value);
    this.getAccountByName(userName);
  }
  refreshAccount(){
    this.getAccountByName(this.account?.name);
    alert("Uspesno osvezavanje");
  }

  resetAccount(){
    ((document.getElementById("userNameSearchInput") as HTMLInputElement).value) = "";
    this.account = new Account();
    this.accountLoaded = false;
  }

  /*async getAccountByName(name: string){
    var result = await this.zzggService.getAccountByName(name).toPromise();
    if(result != null){
      this.account = result;
    }
  }*/

  async getAccountByName(name: string | null = ""){
    await this.zzggService.getAccountByName(name).subscribe(response =>{
      if(response != null){
        this.account = response;
        this.accountLoaded = true;
        this.getIconImg(this.account.profileIconId);
        this.getTotalChampionMasteryScoreBySummonerId(this.account.id);
        this.getAllChampionScoreBySummonerId(this.account.id);
      }
    });
  }


  async getIconImg(iconId: number | undefined){
    await this.zzggService.getIcon(iconId).subscribe(response => {
      if(response != null){
        this.icon = response.url;
      }
    });
    
  }

  async getVersion(){
    await this.zzggService.getVersion().subscribe((data)=>{
      this.version = data.version;
    });
  }

  async getTotalChampionMasteryScoreBySummonerId(summonerId: string | null = ""){
    await this.zzggService.getTotalChampionMasteryScoreBySummonerId(summonerId).subscribe((data)=>{
      this.score = data.score;
    });
  }


  async getAllChampionScoreBySummonerId(summonerId: string | null = ""){
    await this.zzggService.getAllChampionScoreBySummonerId(summonerId).subscribe((data)=>{
      this.championsByAcc = data.slice(0, 3);
      console.log(this.championsByAcc[0])
      this.championIcon = "championIcons/Zed.png"
    });
  }



}

