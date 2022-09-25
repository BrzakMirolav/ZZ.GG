import { Component, OnInit } from '@angular/core';

import { ZzggService } from '../services/zzgg.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  constructor(private zzggService: ZzggService) {
    
   }
   getImg: string | null = "";
   itemImageUrl: string | null = "";
   errors: string | null = "";
  
  ngOnInit(): void {
    this.getIconImg();
    //this.itemImageUrl = this.getIconImg();// "https://ddragon.leagueoflegends.com/cdn/12.18.1/img/profileicon/4791.png" //this.zzggService.getIcon();
  }


  /*getIconImg() {
    this.zzggService.getIcon()
    .subscribe((data) => {
      if(data != null)
      this.getImg = data.body
  })
  console.log(this.getImg)
  return this.getImg;
  }*/

  /*getIconImg(){
    this.zzggService.getIcon().subscribe(
      result => {
        // Handle result
        console.log(result)
        this.getImg = result;
      },
      error => {
        this.errors = error;
        console.log(this.errors)
      },
      () => {
        // 'onCompleted' callback.
        // No errors, route to new page here
      }
    );
    return this.getImg;
  }*/
  getIconImg(){
    this.zzggService.getIcon().subscribe(data=>{
      console.log(data);
    })
  }
}

