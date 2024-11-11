<script setup>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { AppState } from '@/AppState.js';

const theme = ref(loadState('theme') || 'light')

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}

const account = computed(() => AppState.account)
</script>

<template>



    <nav class="navbar p-1 navbar-expand-sm w-100 shadow-sm">
      <button class="navbar-toggler bg-success" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarText">

        <ul class="navbar-nav me-auto p-2">
          <li>
            <router-link :to="{ name: 'Home' }"
              class="btn bg-success fw-bold m-1  rounded-3 lighten-30 selectable text-uppercase">
              Home
            </router-link>
          </li>
          <div v-if="account?.id" class="dropdown">

            <a class="btn btn fw-bold rounded-3 lighten-30 selectable text-uppercase dropdown-toggle m-1" href="#"
              role="button" data-bs-toggle="dropdown" aria-expanded="false">
              Create
            </a>

            <ul class="dropdown-menu bg-secondary">
              <li>
                <p data-bs-toggle="modal" data-bs-target="#createVaultModal"
                  class="btn d-flex align-items-center  bg-secondary fw-bold lighten-30 selectable  text-uppercase"
                  role="button">Create
                  Vault</p>
              </li>
              <hr>
              <li>
                <p data-bs-toggle="modal" data-bs-target="#createKeepModal"
                  class="btn d-flex align-items-center    bg-secondary fw-bold m-1 selectable text-uppercase"
                  role="button">Create
                  Keep</p>
              </li>
            </ul>
          </div>


        </ul>
        <div class="w-50">
          <img class="img-fluid keeper-img" src="/src/assets/img/keepr-logo.png" alt="">
        </div>




        <Login />
      </div>
    </nav>



</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;

}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}

.keeper-img {
  height: 6dvh;
}

.avatar {
  vertical-align: middle;
  width: 50px;
  height: 50px;
  border-radius: 50%;
}
</style>
