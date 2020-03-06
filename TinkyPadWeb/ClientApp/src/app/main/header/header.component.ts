import { Component, OnInit } from '@angular/core';
import { PadService } from 'src/app/shared/pad.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  activeTaskName = '';

  constructor(private padService: PadService) { }

  ngOnInit(): void {
    this.activeTaskName = this.padService.getActiveTask().name;
  }

}
