import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-readmore-content',
  templateUrl: './readmore-content.component.html',
  styleUrls: ['./readmore-content.component.scss']
})
export class ReadmoreContentComponent implements OnInit {
  @Input() content!: string
  @Input() displayLength!: number

  showReadMoreButton!: boolean
  displayedContent: string = ""

  ngOnInit(): void {
    this.showContent();
  }
  showContent() {
    if (!this.content) return;
    this.displayedContent = this.content.slice(0, this.displayedContent.length + this.displayLength)
    this.showReadMoreButton = this.displayedContent.length < this.content.length
  }

}
