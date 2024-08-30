<script setup>
import { AppState } from '@/AppState.js';
import VaultKeepCard from '@/components/VaultKeepCard.vue';

import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';
const route = useRoute()
const router = useRouter()
const vaultKeep = computed(() => AppState.vaultKeeps)
// const keeps = computed(() => AppState.keeps)

watch(() => route.params.vaultId, () => {
  const vaultId = route.params.vaultId
  getVaultKeeps(vaultId)
  getVaultById(vaultId)
}, { immediate: true })
const vault = computed(() => AppState.activeVault)


async function getVaultById(vaultId) {
  try {
    await vaultService.setActiveVault(vaultId)
  }
  catch (error) {
    Pop.toast(error.response.data, 'error');
    router.push({ name: 'Home' })

    logger.error(error)
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
    <div v-for="vaultKeeps in vaultKeep" :key="vaultKeeps.id">
      <VaultKeepCard :vaultProp="vaultKeeps" />
    </div>


  </div>
</template>


<style lang="scss" scoped></style>
