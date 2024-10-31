<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import KeepModal from './components/KeepModel.vue'

</script>

<template>
  <header class="bg-body-secondary">
    <Navbar />
  </header>
  <main class="bg-body-secondary ">
    <router-view />
  </main>
  <footer class="bg-dark text-light bg-body-secondary">
    <p class="btn lighten-30 selectable bg-dark text-light p-2 rounded-pill">Made by Jolama98</p>
  </footer>
  <KeepModal />

</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
