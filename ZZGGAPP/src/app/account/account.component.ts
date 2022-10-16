import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Account } from '../models/account';
import { faSearch, faRefresh, faMoon, faSun } from '@fortawesome/free-solid-svg-icons';
import { ZzggService } from '../services/zzgg.service';
import { AccountChampionStats } from '../models/accountChampionStats';
import { Champion } from '../models/champion';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  faSearch = faSearch;
  faRefresh = faRefresh;
  faMoon = faMoon;
  faSun = faSun;
  constructor(private zzggService: ZzggService) {
    
   }
   version: string | null = "";
   errors: string | null = "";
   account: Account | undefined;
   icon: string | null ="";
   accountLoaded: boolean = false;
   score: number | undefined;
   championsByAcc: Array<AccountChampionStats> | undefined;
   championIconBase = "../../assets/championIcons/";
   champion: Champion | undefined;
  

   /* THEMES */ 
   mainContainerTheme = 'mainContainerDark'
   accountLoadMainDivTheme = 'accountLoadMainDivDark'
   userNameSearchInpuTheme = 'userNameSearchInputDark'
   searchButtonTheme = 'searchButtonDark'
   resetButtonTheme = 'resetButtonDark'
   refreshButtonTheme = 'refreshButtonDark'
   championHrTheme = 'championHrDark'
   labelParagraphTheme = 'labelParagraphDark'
   labelDataParagraphTheme = 'labelDataParagraphDark'
   title1Theme = 'title1Dark'
   title2Theme = 'title2Dark'
   /*--------*/

  ngOnInit(): void {
    this.getAccountByName("raben"); 
    this.getVersion();
  }

  changeSelection(isChecked: any){
    if(isChecked.target.checked == true){
      this.mainContainerTheme = 'mainContainerLight'
      this.accountLoadMainDivTheme = 'accountLoadMainDivLight'
      this.userNameSearchInpuTheme = 'userNameSearchInputLight'
      this.searchButtonTheme = 'searchButtonLight'
      this.resetButtonTheme = 'resetButtonLight'
      this.refreshButtonTheme = 'refreshButtonLight'
      this.championHrTheme = 'championHrLight'
      this.labelParagraphTheme = 'labelParagraphLight'
      this.labelDataParagraphTheme = 'labelDataParagraphLight'
      this.title1Theme = 'title1Light'
      this.title2Theme = 'title2Light'
    }
    else{
      this.mainContainerTheme = 'mainContainerDark'
      this.accountLoadMainDivTheme = 'accountLoadMainDivDark'
      this.userNameSearchInpuTheme = 'userNameSearchInputDark'
      this.searchButtonTheme = 'searchButtonDark'
      this.resetButtonTheme = 'resetButtonDark'
      this.refreshButtonTheme = 'refreshButtonDark'
      this.championHrTheme = 'championHrDark'
      this.labelParagraphTheme = 'labelParagraphDark'
      this.labelDataParagraphTheme = 'labelDataParagraphDark'
      this.title1Theme = 'title1Dark'
      this.title2Theme = 'title2Dark'
    }
  }

  searchAccount(){
    if(this.userNameSearchInpuTheme == 'userNameSearchInputDark')
      var userName = ((document.getElementById("userNameSearchInputDark") as HTMLInputElement).value);
    else
      var userName = ((document.getElementById("userNameSearchInputLight") as HTMLInputElement).value);
    this.getAccountByName(userName);
  }

  refreshAccount(){
    this.getAccountByName(this.account?.name);
    alert("Uspesno osvezavanje");
  }

  resetAccount(){
    if(this.userNameSearchInpuTheme == 'userNameSearchInputDark')
      ((document.getElementById("userNameSearchInputDark") as HTMLInputElement).value) = "";
    else
      ((document.getElementById("userNameSearchInputLight") as HTMLInputElement).value) = "";
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
      if(response.data != null && response.success == true){
        this.account = response.data;
        this.accountLoaded = true;
        this.getIconImg(this.account.profileIconId);
        this.getTotalChampionMasteryScoreBySummonerId(this.account.id);
        this.getAllChampionScoreBySummonerId(this.account.id);
        //this.championIcon = this.championIconBase + 
        //this.championIcon = "../../assets/championIcons/Zed.png";
      }
      else{
        alert(response.message?.text);
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
    let tempData= new Array<AccountChampionStats>();
    let tempChampions = new Array<AccountChampionStats>();
    
    await this.zzggService.getAllChampionScoreBySummonerId(summonerId).subscribe((data)=>{
      //tempData = data.slice(0, 3); 

      this.championsByAcc = data.slice(0,3)
      this.championsByAcc.forEach(element=>{
        let tempImage = element.championIcon;
        element.championIcon = this.championIconBase + tempImage;
      })
     // console.log(this.championsByAcc[0])
    });
   // console.log(this.championsByAcc)
   /* tempData.forEach(async champion=>{
      let tempAccountChampionStats = new AccountChampionStats();
      let tempChampion = new Champion();
      tempChampion = await this.getChampionById(champion.championId);
      tempAccountChampionStats.championName = tempChampion.name;
      tempAccountChampionStats.championIcon = this.championIconBase + tempChampion.image;
      
      tempChampions.push(tempAccountChampionStats);
    })

    this.championsByAcc = tempChampions;*/

  }

  async getChampionById(championId: number | undefined){
    let tempChampion = new Champion();
    await this.zzggService.getChampionById(championId).subscribe((data)=>{
      if(data != null){
        tempChampion = data;
      }
    })
    console.log(tempChampion)
    return tempChampion;
  }

}



