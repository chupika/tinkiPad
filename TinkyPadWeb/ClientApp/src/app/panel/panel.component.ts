import { Component, OnInit } from '@angular/core';
import { PanelService } from './panel.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.css']
})
export class PanelComponent implements OnInit {

  constructor(private panelService: PanelService, private router: Router) { }

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
}
