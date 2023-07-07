import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  // public static readonly darkThemeClassName = 'app-dark-mode';
  // theme: 'light' | 'dark' = 'light';
  // private readonly renderer: Renderer2;
  //
  // constructor(rendererFactory: RendererFactory2, private overlay: OverlayContainer) {
  //   this.renderer = rendererFactory.createRenderer(null, null);
  //   if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
  //     this.theme = 'dark';
  //   }
  //   this.renderer[this.theme === 'dark' ? 'addClass' : 'removeClass'](
  //     document.querySelector('body'),
  //     AppComponent.darkThemeClassName
  //   );
  //   if (this.theme === 'dark') {
  //     this.overlay.getContainerElement().classList.add(AppComponent.darkThemeClassName);
  //   } else {
  //     this.overlay.getContainerElement().classList.remove(AppComponent.darkThemeClassName);
  //   }
  // }
}
