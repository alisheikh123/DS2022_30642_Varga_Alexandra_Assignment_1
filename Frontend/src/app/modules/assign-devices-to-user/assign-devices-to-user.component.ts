import { ApiService } from '@/shared/services/api.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import moment from 'moment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-assign-devices-to-user',
  templateUrl: './assign-devices-to-user.component.html',
  styleUrls: ['./assign-devices-to-user.component.scss']
})
export class AssignDevicesToUserComponent implements OnInit {
  users:any;
  devices:any;
  devicetouserForm!:FormGroup
  constructor(private apiService:ApiService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getIntializedForm();
    this.getUserName();
    this.getDeviceName();
  }
  getIntializedForm(){
    this.devicetouserForm = new FormGroup({
      userId: new FormControl('', Validators.required),
      deviceId: new FormControl('',  Validators.required),
      assigningDate: new FormControl('', )
    });
  }
  getUserName()
  {
    this.apiService.serviceGet("accounts/GetUsers").then((response:any)=>{
      this.users = response?.data;
      console.log(this.users)
    });
  }
 getDeviceName(){
  this.apiService.serviceGet("DeviceTbls").then((res:any)=>{
    this.devices = res;
  });
}
selectUserId(event:any){
  this.devicetouserForm.patchValue({
    userId:event.target.value
  })
}
selectDeviceId(event:any){
  this.devicetouserForm.patchValue({
    deviceId:event.target.value
  })
}
onSave(){
  console.log(this.devicetouserForm)

  if(this.devicetouserForm.valid){
    this.devicetouserForm.patchValue({
      assigningDate:moment(this.devicetouserForm.controls['assigningDate'].value).format('YYYY-MM-DD')
    })
    this.apiService.servicePost("UserDeviceMappingTbls",this.devicetouserForm.value).then((res:any)=>{
      if(res !=null){
      this.toastr.success("Device successfully assigned to user");
      this.devicetouserForm.reset();
      window.location.reload();
      }
      else{
        this.toastr.warning("Something wrong in form");
      }
    });
  }
}
}
