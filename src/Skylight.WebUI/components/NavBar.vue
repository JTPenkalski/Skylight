<script setup lang="ts">
import { Button } from 'primevue';

//import { useLayout } from '@/layout/composables/layout';
function getThemeIcon(): string {
	return `pi ${isDarkTheme ? 'pi-moon' : 'pi-sun'}`;
}

//const { toggleMenu, toggleDarkMode, isDarkTheme } = useLayout();
const isDarkTheme: boolean = true;
</script>

<template>
  <div class="navbar flex flex-row items-center justify-between
    fixed left-0 top-0 p-2
    w-full z-10">
    <div class="flex flex-row items-center gap-1">
      <a href="/">
        <img alt="logo" class="w-[8rem] md:w-[12rem]" src="~/assets/logo_full.svg" />
      </a>
    </div>

    <div class="flex flex-row items-center">
      <!-- <Button rounded icon="pi pi-inbox" severity="contrast" variant="text" aria-label="Notifications" /> -->
      <!-- <Button rounded :icon="getThemeIcon()" severity="contrast" variant="text" aria-label="Theme" /> -->
    </div>
  </div>
</template>

<style scoped lang="css">
.navbar {
  background-color: var(--p-content-background);
  border-bottom: 2px solid var(--p-sky-500);
  height: var(--p-navbar-height);
}
</style>
