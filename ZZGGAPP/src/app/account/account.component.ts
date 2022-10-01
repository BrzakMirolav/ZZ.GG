import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Account } from '../models/account';
import { faSearch, faRefresh } from '@fortawesome/free-solid-svg-icons';
import { ZzggService } from '../services/zzgg.service';

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
      }
    });
  }


  async getIconImg(iconId: number | undefined){
    await this.zzggService.getIcon(iconId).subscribe(response => {
      if(response != null){
        this.icon = response.url;
        console.log(response)
      }
    });
    
  }

  async getVersion(){
    await this.zzggService.getVersion().subscribe((data)=>{
      console.log(data)
      this.version = data.version;
    }) ;
    //return this.version;
  }
}

