// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  app: {
    head: {
      htmlAttrs: {
        lang: 'en',
      },
      link: [
        { rel: 'icon', href: '/favicon.ico' },
        { rel: 'preconnect', href: 'https://fonts.googleapis.com' },
        { rel: 'preconnect', href: 'https://fonts.gstatic.com', crossorigin: '' },
        { rel: 'stylesheet', href: 'https://fonts.googleapis.com/css2?family=Oxanium:wght@200..800&family=Sunflower:wght@300;500;700&display=swap' },
      ],
      meta: [
        { charset: "utf-8" },
        { name: 'viewport', content: 'width=device-width, initial-scale=1' }
      ],
      title: 'Skylight',
    }
  },
  compatibilityDate: '2024-11-01',
  css: [
    '~/assets/scss/main.scss'
  ],
  devServer: {
    port: parseInt(process.env.PORT ?? "57107")
  },
  devtools: {
    enabled: true
  },
  typescript: {
    typeCheck:  true,
  }
});
