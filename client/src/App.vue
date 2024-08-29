<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import KeepModal from './components/KeepModel.vue'

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">

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
