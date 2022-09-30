import { Component, OnInit } from '@angular/core';
import { Account } from '../models/account';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { ZzggService } from '../services/zzgg.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  faSearch = faSearch;
  constructor(private zzggService: ZzggService) {
    
   }
   getImg: string | null = "";
   itemImageUrl: string | null = "";
   errors: string | null = "";
   account: Account | undefined;
   icon: string | null ="";
   accountLoaded: boolean = false;
  
  ngOnInit(): void {

  }

  searchAccount(){
    var userName = ((document.getElementById("userNameSearch") as HTMLInputElement).value);
    this.getAccountByName(userName);
  }

  /*async getAccountByName(name: string){
    var result = await this.zzggService.getAccountByName(name).toPromise();
    if(result != null){
      this.account = result;
    }
  }*/


  async getAccountByName(name: string){
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
    let serviceResult: any;
    await this.zzggService.getVersion().subscribe((data)=>{
      serviceResult = data.version;
    }) ;
    return serviceResult;
  }

}

