<script setup>

import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import Pop from '../utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';
import VaultCard from '@/components/VaultCard.vue';
import CreateKeepForm from '../components/CreateKeepFrom.vue';
import { profilesService } from '@/services/ProfilesService.js';
import CreateVaultForm from '@/components/CreateVaultForm.vue';


const route = useRoute()
const keeps = computed(() => AppState.profileKeeps)
const vaults = computed(() => AppState.profileVaults)
const profile = computed(() => AppState.profile)


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
    <div v-if="profile" class="container pb-3">
      <section class="row">
        <div class="col-12">
          <div class="d-flex justify-content-center ">

            <img :src="profile.coverImg" :alt="profile.coverImg"
            class="img-fluid cover-img">
          </div>
          <div class="d-flex flex-column align-items-center   ">
            <img :src="profile.picture" :alt="profile.name" class="avatar border">
            <h1 class="profile-name text-dark">{{ profile.name }}</h1>
          </div>
        </div>
      </section>
    </div>
    <p class="fs-1 fw-bolder">Vaults</p>
    <div class="row">
      <div class="col-12">
        <div class="masonry-layout">
          <div v-for="vault in vaults" :key="vault.id" class="masonry-item">
            <VaultCard :vaultProp="vault" />

          </div>
        </div>
      </div>
    </div>
    <p class="fs-1 fw-bolder">Keeps</p>
    <div class="row">
      <div class="col-12">

        <div class="d-flex justify-content-center masonry-layout">

          <div v-for="keep in keeps" :key="keep.id" class="masonry-item">
            <KeepCard :keepProps="keep" />
          </div>

        </div>
      </div>
    </div>
  </div>
  <CreateVaultForm />
  <CreateKeepForm />
</template>


<style lang="scss" scoped>
.cover-img {
  height: 60vh;
  background-image: v-bind('profile?.backgroundImage');
  background-repeat: no-repeat;

}

.avatar {
  vertical-align: middle;
  width: 10vh;
  height: 10vh;
  border-radius: 50%;
  position: relative;
  top: -30px;
}

.profile-name {
  position: relative;
  top: -40px;
  text-shadow: 1px 1px 20px rgb(227, 226, 226), 0 0 1em rgba(133, 133, 133, 0.263), 0 0 0.2em rgba(255, 255, 255, 0.169);
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

@media (max-width: 480px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>
