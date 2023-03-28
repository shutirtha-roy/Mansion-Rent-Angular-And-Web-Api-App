import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    imageUrl: '',
    amenity: '',
    createdDate: new Date(),
    updatedDate: new Date()
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

  deleteMansion(id: string) {
    this.mansionService.deleteMansion(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['mansion']);
      }
    });
  }
}