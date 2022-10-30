import { AppService } from '@/shared/services/app.service';
import {Component} from '@angular/core';


@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
isAdmin:boolean=false;
  /**
   *
   */
  constructor(private appService:AppService) {


  }
  ngOnInit(): void {
    this.checkRole();
  }
  checkRole(){
    let role = this.appService.getRole();
    if(role==null){
     this.isAdmin=false;
    }
    if(role=="Client" ){
     this.isAdmin=false;
    }
    if(role=="Admin" ){
     this.isAdmin=true;
    }

 }
}
