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
            <div class="flex-column align-items-center d-flex">
              <img class="cover-img" :src="vault.img" alt="">
              <h1 class="d-flex justify-content-center ">{{ vault.name }}</h1>
              <p class="d-flex justify-content-center ">{{ vault.description }}</p>
              <div class="d-inline-flex">
                <p class="bg-secondary rounded-3 p-1 "> {{ vaultKeep.length }} <samp>
                    Keeps</samp></p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>




    <div class="masonry-layout ">
      <div v-for="vault in vaultKeep" :key="vault.id" class="masonry-item">
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


.masonry-layout {
  column-count: 4;
  column-gap: 1rem;
  width: 100%;
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 1rem;
}

@media (max-width: 768px) {
  .masonry-layout {
    column-count: 3;
  }
}

@media (max-width: 550px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>
