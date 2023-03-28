import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
    imageurl: '',
    amenity: '',
    createdDate: new Date(),
    updatedDate: new Date()
  };

  constructor(private mansionService: MansionService, private router: Router, private toastr: ToastrService) { }

  addMansion() {
    this.mansionService.addMansion(this.addMansionRequest)
    .subscribe({
      next: (mansion) => {
        this.toastr.success("Mansion added successfully");
        this.router.navigate(['/mansion']);
      }
    });
  }
}