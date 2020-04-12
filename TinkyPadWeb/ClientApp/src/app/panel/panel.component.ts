import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PageService } from '../shared/page.service';
import { PadService } from '../shared/pad.service';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.css']
})
export class PanelComponent implements OnInit {

  constructor(private pageService: PageService, private padService: PadService, private router: Router) {}

  ngOnInit() {
  }

  onNewTask() {
    this.router.navigate(['new']);
  }

  onChoose() {
    
  }

  onComplete() {

  }

  onInterrupt() {

  }

  onTurnThePage() {

  }

  chooseTaskAvailable() {
    return this.pageService.selectedTaskIndexOnPage != null;
  }
}
