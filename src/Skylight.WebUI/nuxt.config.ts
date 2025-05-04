import { definePreset } from '@primeuix/themes';
import Aura from '@primeuix/themes/aura';
import type { Preset } from '@primeuix/themes/types';

const theme: Preset = definePreset(Aura, {
	semantic: {
		primary: {
			50: '{blue.50}',
			100: '{blue.100}',
			200: '{blue.200}',
			300: '{blue.300}',
			400: '{blue.400}',
			500: '{blue.500}',
			600: '{blue.600}',
			700: '{blue.700}',
			800: '{blue.800}',
			900: '{blue.900}',
			950: '{blue.950}',
		},
	},
});

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
	//ssr: false,
	app: {
		head: {
			htmlAttrs: {
				lang: 'en',
			},
			link: [
				{ rel: 'icon', href: '/favicon.ico' },
				{ rel: 'preconnect', href: 'https://fonts.googleapis.com' },
				{ rel: 'preconnect', href: 'https://fonts.gstatic.com', crossorigin: '' },
				{
					rel: 'stylesheet',
					href: 'https://fonts.googleapis.com/css2?family=Oxanium:wght@200..800&family=Sunflower:wght@300;500;700&display=swap',
				},
			],
			meta: [
				{ charset: 'utf-8' },
				{ name: 'viewport', content: 'width=device-width, initial-scale=1' },
			],
			title: 'Skylight',
		},
	},
	compatibilityDate: '2024-11-01',
	css: ['~/assets/scss/main.scss'],
	devtools: {
		enabled: true,
	},
	modules: ['@primevue/nuxt-module'],
	primevue: {
		options: {
			ripple: false,
			inputVariant: 'filled',
			theme: {
				preset: theme,
				options: {
					prefix: 'p',
					darkModeSelector: 'system',
					cssLayer: false,
				},
			},
		},
	},
	runtimeConfig: {
		public: {
			apiBaseSkylight: 'https://localhost:7266/api/',
			logClients: true,
		},
	},
	$production: {
		runtimeConfig: {
			public: {
				logClients: false,
			},
		},
	},
	typescript: {
		typeCheck: true,
	},
});
