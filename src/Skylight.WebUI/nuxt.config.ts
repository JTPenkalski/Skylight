import { definePreset } from '@primeuix/themes';
import Aura from '@primeuix/themes/aura';
import tailwindcss from '@tailwindcss/vite';

const theme = definePreset(Aura, {
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
	extend: {
		navbar: {
			height: '3rem',
		},
		severity: {
			high: {
				color: '{fuchsia.600}',
				background: 'color-mix(in srgb, {fuchsia.400}, transparent 60%)',
			},
			moderate: {
				color: '{red.600}',
				background: 'color-mix(in srgb, {red.400}, transparent 60%)',
			},
			enhanced: {
				color: '{orange.600}',
				background: 'color-mix(in srgb, {orange.400}, transparent 60%)',
			},
			slight: {
				color: '{yellow.600}',
				background: 'color-mix(in srgb, {yellow.400}, transparent 60%)',
			},
			marginal: {
				color: '{green.600}',
				background: 'color-mix(in srgb, {green.400}, transparent 60%)',
			},
		},
	},
});

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
	// ssr: false,
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
	css: ['~/assets/css/main.css'],
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
					cssLayer: {
						name: 'primevue',
						order: 'theme, base, primevue',
					},
				},
			},
		},
	},
	runtimeConfig: {
		public: {
			apiBaseSkylight: 'https://localhost:7266/api/',
			logging: {
				clients: true,
				hubs: true,
			},
		},
	},
	vite: {
		plugins: [tailwindcss()],
	},
	typescript: {
		typeCheck: true,
	},
	$production: {
		runtimeConfig: {
			public: {
				logging: {
					clients: false,
					hubs: false,
				},
			},
		},
	},
});
