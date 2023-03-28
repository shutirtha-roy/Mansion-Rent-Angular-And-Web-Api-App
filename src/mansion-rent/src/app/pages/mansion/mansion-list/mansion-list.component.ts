import { Component, OnInit } from '@angular/core';
import { MansionService } from 'src/app/services/mansion.service';
import { IMansionApiResponse, IMansionResult } from 'src/assets/data/IMansionApiResonse';

@Component({
  selector: 'app-mansion-list',
  templateUrl: './mansion-list.component.html',
  styleUrls: ['./mansion-list.component.css']
})
export class MansionListComponent implements OnInit{
  mansionlist!: IMansionResult;

  constructor(private mansionService: MansionService) { }

  ngOnInit(): void {
    this.mansionService.getAllMansions()
    .subscribe({
      next: (mansions) => {
        //console.log(employees);
        this.mansionlist = mansions.result;
        console.log(this.mansionlist);
      },
      error: (response) => {
        console.log(response)
      }
    });
  } 
}
