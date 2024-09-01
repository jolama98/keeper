<script setup>
import { AppState } from '@/AppState.js';
import VaultKeepCard from '@/components/VaultKeepCard.vue';

import { vaultService } from '@/services/VaultService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, vShow, watch } from 'vue';
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
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <div class="d-flex justify-content-center">
            <div class="">

              <img class="cover-img" :src="vault.img" alt="">
              <h1>{{ vault.name }}</h1>
              <p>{{ vault.description }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-3 ">
      <div v-for="vault in vaultKeep" :key="vault.id">
        <VaultKeepCard :vaultProp="vault" />
      </div>
    </div>

  </div>
</template>


<style lang="scss" scoped>
.cover-img {
  height: 30vh;
  background-size: cover;
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>
