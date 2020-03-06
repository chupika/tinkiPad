import { Component, OnInit } from '@angular/core';
import { PadService } from '../shared/pad.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-active-task',
  templateUrl: './active-task.component.html',
  styleUrls: ['./active-task.component.css']
})
export class ActiveTaskComponent implements OnInit {

  constructor(private padService: PadService, private router: Router) { }

  ngOnInit(): void {
    if (!this.padService.isActiveTaskChosen()) {
      this.router.navigate(['main']);
    }
  }

}
