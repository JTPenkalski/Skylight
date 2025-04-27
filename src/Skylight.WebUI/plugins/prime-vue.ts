import Lara from '@primeuix/themes/lara';
import PrimeVue from 'primevue/config';

export default defineNuxtPlugin((nuxtApp) => {
	nuxtApp.vueApp.use(PrimeVue, {
		theme: {
			preset: Lara,
			options: {
				prefix: 'p',
				darkModeSelector: 'system',
			},
		},
	});
});
