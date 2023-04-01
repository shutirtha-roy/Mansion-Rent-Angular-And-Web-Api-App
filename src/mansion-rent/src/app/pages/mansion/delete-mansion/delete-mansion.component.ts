import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MansionService } from 'src/app/services/mansion.service';
import { IMansionResult } from 'src/assets/data/IMansionApiResonse';

@Component({
  selector: 'app-delete-mansion',
  templateUrl: './delete-mansion.component.html',
  styleUrls: ['./delete-mansion.component.css']
})
export class DeleteMansionComponent implements OnInit {
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
    private toastr: ToastrService) { 
    
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.mansionService.getMansion(id)
          .subscribe({
            next: (response) => {
              this.mansion = Object.assign(response.result);
            }
          });
        }
      }
    })
  }

  deleteMansion(id: string) {
    this.mansionService.deleteMansion(id)
    .subscribe({
      next: (response) => {
        this.toastr.success('Mansion delete successfully.')
        this.router.navigate(['mansion']);
      }
    });
  }
}