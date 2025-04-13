import './assets/main.scss';

import Lara from '@primeuix/themes/lara';
import PrimeVue from 'primevue/config';
import { createApp } from 'vue';
import App from './App.vue';

const app = createApp(App);
app.use(PrimeVue, {
	theme: {
		preset: Lara,
		options: {
			prefix: 'p',
			darkModeSelector: 'system',
		},
	},
});

app.mount('#app');
