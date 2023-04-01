import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscriber } from 'rxjs';
import { MansionService } from 'src/app/services/mansion.service';
import { IMansionResult } from 'src/assets/data/IMansionApiResonse';

@Component({
  selector: 'app-edit-mansion',
  templateUrl: './edit-mansion.component.html',
  styleUrls: ['./edit-mansion.component.css']
})

export class EditMansionComponent implements OnInit {
  mansionForm!: FormGroup;
  submitted: boolean = false;
  base64codeImage: string = '';
  
  mansion: IMansionResult = {
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

  constructor(
    private route: ActivatedRoute, 
    private mansionService: MansionService, 
    private router: Router,
    private formBuilder: FormBuilder) { 

    }

  ngOnInit(): void {
    this.mansionForm = this.formBuilder.group({
      id: ['', Validators.required],
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
    
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.mansionService.getMansion(id)
          .subscribe({
            next: (response) => {
              this.mansion = Object.assign(response.result);
              console.log(this.mansion);
              
              this.mansionForm.setValue({
                id: this.mansion.id,
                name: this.mansion.name,
                details: this.mansion.details,
                rate: this.mansion.rate,
                sqft: this.mansion.sqft,
                occupancy: this.mansion.occupancy,
                base64Image: this.mansion.base64Image,
                createdDate: this.mansion.createdDate,
                updatedDate: this.mansion.updatedDate,
                isDeleted: this.mansion.isDeleted
              });

              this.base64codeImage = this.mansion.base64Image;
              
            }
          });
        }
      }
    })
  }
  
  onMansionUpdate() {
    this.submitted = true;

    this.mansionForm.patchValue({
      base64Image: this.mansion.base64Image
    });

    console.log(this.mansionForm.value);

    if(this.mansionForm.valid)
    {
      this.mansionService.updateMansion(this.mansionForm.value)
      .subscribe({
        next: (response) => {
          this.router.navigate(['mansion']);
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
      this.mansion.base64Image = base64Code;
      
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