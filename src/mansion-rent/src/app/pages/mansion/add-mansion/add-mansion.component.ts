import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscriber } from 'rxjs';
import { MansionService } from 'src/app/services/mansion.service';
import { IMansionResult } from 'src/assets/data/IMansionApiResonse';

@Component({
  selector: 'app-add-mansion',
  templateUrl: './add-mansion.component.html',
  styleUrls: ['./add-mansion.component.css']
})
export class AddMansionComponent {  
  addMansionRequest: IMansionResult = {
    id: '',
    name: '',
    details: '',
    rate: '',
    sqft: '',
    occupancy: '',
    base64Image: '',
    createdDate: new Date(),
    updatedDate: new Date(),
    isDeleted: false
  };

  constructor(private mansionService: MansionService, private router: Router, private toastr: ToastrService) { }

  addMansion() {
    console.log(this.addMansionRequest);
    this.mansionService.addMansion(this.addMansionRequest)
    .subscribe({
      next: (mansion) => {
        this.toastr.success("Mansion added successfully");
        this.router.navigate(['/mansion']);
      }
    });
  }

  getImage(event: any)
  {
    this.convertToBase64(event.target.files[0]);
  }

  convertToBase64(file: File) {
    const observable = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });
    observable.subscribe((base64Code) => {
      this.addMansionRequest.base64Image = base64Code
      console.log(base64Code);
    })
  }

  readFile(file: File, subscriber: Subscriber<any>) {
    const filereader = new FileReader();
    filereader.readAsDataURL(file);
    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }
}