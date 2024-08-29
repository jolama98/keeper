<script setup>
import { AppState } from '@/AppState.js';
import { vaultService } from '@/services/VaultService.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';
const route = useRoute()

watch(() => route.params.vaultId, () => {

  getVaultKeeps(route.params.vaultId)
})



const vault = computed(() => AppState.activeVaults)


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
  </div>
</template>


<style lang="scss" scoped></style>
