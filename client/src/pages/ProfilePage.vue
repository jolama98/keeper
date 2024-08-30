<script setup>

import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import Pop from '../utils/Pop.js';
import { computed, onMounted, watch } from 'vue';
import { useRoute } from 'vue-router';
import VaultCard from '@/components/VaultCard.vue';
import CreateKeepForm from '../components/CreateKeepFrom.vue';
import { profilesService } from '@/services/ProfilesService.js';
import CreateVaultForm from '@/components/CreateVaultForm.vue';
import { Vault } from '@/models/Vault.js';
import { vaultService } from '@/services/VaultService.js';

const route = useRoute()
const keeps = computed(() => AppState.profileKeeps)
const vaults = computed(() => AppState.profileVaults)
const profile = computed(() => AppState.profile)
const profileCoverImg = computed(() => `url(${profile.value?.coverImg})`)

watch(() => route.params.profileId, () => {
  const profileId = route.params.profileId
  getProfileById(profileId)
  getKeepsByProfileId(profileId)
  getVaultsByProfileId(profileId)
}, { immediate: true })

async function getProfileById(profileId) {
  try {
    await profilesService.getProfileById(profileId)
  } catch (error) {
    Pop.error(error)
  }
}


async function getKeepsByProfileId(profileId) {
  try {
    await profilesService.getKeepsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}
async function getVaultsByProfileId(profileId) {
  try {
    await profilesService.getVaultsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div class="container">
    <div v-if="profile" class="container">
      <section class="row">
        <div class="col-12">
          <div class="text-center cover-img">
            <img :src="profile.picture" :alt="profile.name" class="avatar">
            <h1>{{ profile.name }}</h1>
          </div>
        </div>
      </section>
    </div>
    <p class="fs-1 fw-bolder">Vaults</p>
    <div class="row">

      <div v-for="vault in vaults" :key="vault.id" class="col-md-3 col-6">
        <VaultCard :vaultProps="vault" />
      </div>
    </div>
    <p class="fs-1 fw-bolder">Keeps</p>
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="img-card col-md-3 col-6 pt-2 ">
        <KeepCard :keepProps="keep" />
      </div>
    </div>
  </div>
  <CreateVaultForm />
  <CreateKeepForm />
</template>


<style lang="scss" scoped>
.avatar {
  vertical-align: middle;
  width: 70px;
  height: 70px;
  border-radius: 50%;
}

.cover-img {
  height: 60vh;
  background-image: v-bind(profileCoverImg);
  background-size: cover;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
</style>
