<script setup>
import { AppState } from '@/AppState.js';
import { vaultKeepService } from '@/services/vaultKeepService.js';
import Pop from '@/utils/Pop.js';
import { computed } from 'vue';
import { useRoute } from 'vue-router';

const keep = computed(() => AppState.setActiveKeep)
const route = useRoute()

// TODO add createVaultKeep method
async function createVaultKeep() {
  try {
    const createVaultKeepData = keep
    await vaultKeepService.createVaultKeep(createVaultKeepData)
  }
  catch (error) {
    Pop.error(error);
  }
}

const accountVault = computed(() => AppState.accountVaults)


</script>


<template>

  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModal" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div v-if="keep" class="modal-content">
        <div class="row">
          <div class="col-md-6 p-0">
            <img class="keep-img img-fluid " :src="keep.img" :alt="keep.name">
          </div>

          <div class="col-md-6  d-flex flex-column justify-content-around">
            <div class="d-flex justify-content-center">
              <p class="mdi mdi-eye p-2"> {{ keep.views }}</p>
              <p class="mdi mdi-sack p-2"> {{ keep.kept }}</p>
            </div>
            <div class="d-flex flex-column text-center ">
              <h1 class="modal-title fs-2" id="keepModal"> {{ keep?.name }}</h1>
              <p class="p-2">{{ keep.description }}</p>
            </div>
            <div class="d-flex align-items-center  justify-content-around    ">


              <button @click="createVaultKeep()" class="btn btn-color btn-dark">Save</button>

              <div class="dropdown">
                <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
                  aria-expanded="false">
                  Vaults
                </a>
                <!-- TODO v-for over AccountVaults -->

                <ul class="dropdown-menu" v-for=" accountVaults in accountVault" :key="accountVaults.id">
                  <li>{{ accountVaults.vaultId }}</li>
                </ul>
              </div>
              <div class="d-flex align-items-center ">

                <RouterLink :to="{ name: 'Profile', params: { profileId: keep.creatorId } }"
                  :title="`Go to ${keep.creator.name}'s profile page`">
                  <img data-bs-dismiss=" modal" aria-label="Close" class="avatar p-1" :src="keep.creator.picture"
                    alt="">
                </RouterLink>
                <p class=" m-0 p-2 creator-name">{{ keep.creator?.name }}</p>
              </div>
            </div>
          </div>


        </div>



      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.keep-img {
  height: 100%;
  background-position: center;
  background-size: cover;
}

.creator-name {
  font-family: marko-one;
  font-weight: bold;
}

h1 {
  text-shadow: 1px 1px 1px rgb(255, 255, 255);
  font-family: marko-one;
  font-weight: bolder;
}

.avatar {
  vertical-align: middle;
  width: 50px;
  height: 50px;
  border-radius: 50%;
}

.btn-color {
  background-color: #877A8F;
}
</style>
