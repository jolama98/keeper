<script setup>
import { vaultService } from '@/services/VaultService.js';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

const account = computed(() => AppState.account.id)
const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

onMounted(() => {
  gatAllKeeps()
  getVaultsById()
})
async function getVaultsById() {
  try {

    await vaultService.getVaultsById(route.params.vaultId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function gatAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div class="container">
    <h1>Vaults</h1>
    {{ vault }}
    <h2>Keeps</h2>
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="img-card col-md-3 col-6 pb-2 ">
        <KeepCard :keepProps="keep" />
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>
