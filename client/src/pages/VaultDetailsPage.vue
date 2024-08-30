<script setup>
import { AppState } from '@/AppState.js';
import { vaultService } from '@/services/VaultService.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()


watch(() => route.params.vaultId, () => {
  const vaultId = route.params.vaultId
  getVaultKeeps(vaultId)
  getVaultById(vaultId)
}, { immediate: true })
const vault = computed(() => AppState.activeVault)


async function getVaultById(vaultId) {
  try {
    vaultService.setActiveVault(vaultId)
  }
  catch (error) {

    // TODO push me away away away from this page

    Pop.error(error);
  }
}
async function getVaultKeeps(vaultId) {
  try {
    await vaultService.getVaultKeeps(vaultId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div v-if="vault">
    <h1>Vaults Details</h1>
    <h2>{{ vault.name }}</h2>
    <img :src="vault.img" alt="">
    <p>{{ vault.description }}</p>

    <!-- TODO VAULTPAGE v-for over the vaultKeeps -->

  </div>
</template>


<style lang="scss" scoped></style>
