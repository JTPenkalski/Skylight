import './assets/main.scss';

import Lara from '@primeuix/themes/lara';
import PrimeVue from 'primevue/config';
import { createApp } from 'vue';
import App from './App.vue';

const app = createApp(App);

app.config.globalProperties.$filters = {
	pluralize(text: string, amount: number): string {
		const normalizedAmount = Math.abs(amount);

		return normalizedAmount === 1 ? text : `${text}s`;
	},
};

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
