import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
export class AddMansionComponent implements OnInit {  
  mansionForm!: FormGroup;
  submitted: boolean = false;
  base64codeImage: string = '';

  constructor(
    private mansionService: MansionService, 
    private router: Router, 
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { 

  }

  ngOnInit(): void {
      this.mansionForm = this.formBuilder.group({
        name: ['', Validators.required],
        details: ['', Validators.required],
        rate: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
        sqft: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
        occupancy: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
        base64Image: ['', Validators.required],
        createdDate: [new Date()],
        updatedDate: [new Date()],
        isDeleted: [false]
      });
  }

  onMansionSubmit() {
    this.submitted = true;
    console.log(this.mansionForm.value);

    if(this.mansionForm.valid)
    {
      this.mansionService.addMansion(this.mansionForm.value)
      .subscribe({
        next: (mansion) => {
          this.toastr.success("Mansion added successfully");
          this.router.navigate(['/mansion']);
        }
      });
    }

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
      this.base64codeImage = base64Code;
      this.mansionForm.patchValue({
        base64Image: base64Code
      });
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