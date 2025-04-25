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
  <div class="navbar">
    <div class="navbar-logo-container">
      <Button rounded icon="pi pi-bars" severity="contrast" variant="text" aria-label="Menu" />
      <a href="/" class="navbar-logo">
        <img alt="logo" src="../assets/logo_full.svg" />
      </a>
    </div>

    <div class="navbar-action-container hello">
      <Button rounded :icon="getThemeIcon()" severity="contrast" variant="text" aria-label="Theme" />
      <Button rounded icon="pi pi-inbox" severity="contrast" variant="text" aria-label="Notifications" />
      <Button rounded icon="pi pi-user" severity="contrast" variant="text" aria-label="Profile" />
    </div>
  </div>
</template>

<style scoped lang="scss">
.navbar {
  align-items: center;
  background-color: var(--p-content-background);
  display: flex;
  height: 3rem;
  left: 0;
  padding: 0 1rem;
  position: fixed;
  top: 0;
  width: 100%;
}

.navbar-logo-container {
  align-items: center;
  display: flex;
  gap: 1rem;

  .navbar-logo {
    display: flex;

    img {
      width: 10rem;
    }
  }
}

.navbar-action-container {
  align-items: center;
  display: flex;
  gap: 1rem;
  margin-left: auto;
}

@media (max-width: 767px) {
  .navbar {
    align-items: center;
    background-color: var(--p-content-background);
    display: flex;
    height: 3rem;
    left: 0;
    padding: 0 1rem;
    position: fixed;
    top: 0;
    width: 100%;
  }

  .navbar-logo-container {
    align-items: center;
    display: flex;
    gap: 1rem;

    .navbar-logo {
      display: flex;

      img {
        width: 8rem;
      }
    }
  }

  .navbar-action-container {
    align-items: center;
    display: flex;
    gap: 1rem;
    margin-left: auto;
  }
}
</style>
