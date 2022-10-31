import { ApiService } from '@/shared/services/api.service';
import { AppService } from '@/shared/services/app.service';
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Chart, registerables } from 'chart.js';
import moment from 'moment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.scss']
})
export class BarchartComponent implements OnInit {
  isSubmitted = false;
  userDevices:any;
  index:number=0;
  barchartForm = this.fb.group({
    userId: ['', ],
    deviceId: ['', [Validators.required]],
    creationDate:['',[Validators.required]]
  });
  public chart: any;
  datePicker:any;
  User: any = ['Florida', 'South Dakota', 'Tennessee', 'Michigan'];
  Device: any = ['Nokia', 'South Dakota', 'Tennessee', 'Michigan'];

  constructor(public fb: FormBuilder,private apiService:ApiService,private toast:ToastrService,
    private appService:AppService) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    this.getUserId();
  }
  getUserId(){

    let userId  = localStorage.getItem('userId');
     this.apiService.serviceGet(`DeviceTbls/GetDevices/${userId}`).then((res:any)=>{
      this.userDevices =  res?.data;

    })

  }
  createChart(response:any){
    debugger
    console.log(response?.data.length);
    debugger
    for(this.index=0;this.index< response?.data.length;this.index++){
      debugger
      this.chart = new Chart("MyChart", {
        type: 'bar', //this denotes tha type of chart

        data: {// values on X-Axis
          labels: [response?.data[this.index]?.createdDate],
          //  ,'2022-05-13',
          // 				 '2022-05-14', '2022-05-15', '2022-05-16','2022-05-17', ],
           datasets: [
            {
              label: "Hours",
              data: [response?.data[this.index]?.hours],
              backgroundColor: 'green'
            },
            {
              label: "Energy Consumption(Kwh)",
              data: [response?.data[this.index]?.energyConsumption],
              backgroundColor: 'skyblue'
            }
          ]
        },
        options: {
          aspectRatio:2.3
        }

      });
    }

  }

  changeDevice(event: any) {

    this.barchartForm.patchValue({
      deviceId:event.target.value
    })
  }
  onSubmit(): void {
    debugger;
    this.barchartForm.controls.creationDate.setValue(this.barchartForm.controls.creationDate.value);
    this.barchartForm.patchValue({
      userId:localStorage.getItem('userId')
    })
   let model = this.barchartForm.value;
    this.isSubmitted = true;
    if (this.barchartForm.valid) {
      this.barchartForm.patchValue({
        creationDate:moment(this.barchartForm.controls['creationDate'].value).format('MM-DD-YYYY')
      })
console.log(this.barchartForm.value)

        this.apiService.serviceGet(`AfterMappingStoredHourEnergies/GenerateReport?userId=${this.barchartForm.get('userId').value}&deviceId=${this.barchartForm.get('deviceId').value}&creationDate=${this.barchartForm.get('creationDate').value}`).then((res:any)=>{
          if(res?.statusCode=="Ok"){
            debugger
            this.createChart(res);
          }
          else{
            this.toast.warning(res?.message);
          }

        })
    } else {

      console.log(JSON.stringify(this.barchartForm.value));
    }
  }
}
