import './assets/main.css';

import Lara from '@primeuix/themes/lara';
import PrimeVue from 'primevue/config';
import { createApp } from 'vue';
import App from './App.vue';

const app = createApp(App);
app.use(PrimeVue, {
	theme: {
		preset: Lara,
	},
});

app.mount('#app');
