import { Component, OnInit } from '@angular/core';
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

  constructor(private route: ActivatedRoute, private mansionService: MansionService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.mansionService.getMansion(id)
          .subscribe({
            next: (response) => {
              
              this.mansion = Object.assign(response.result);
              console.log(this.mansion);
            }
          });
        }
      }
    })
  }

  updateMansion() {
    this.mansionService.updateMansion(this.mansion)
    .subscribe({
      next: (response) => {
        this.router.navigate(['mansion']);
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
      this.mansion.base64Image = base64Code
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