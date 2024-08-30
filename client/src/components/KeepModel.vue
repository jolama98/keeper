<script setup>
import { AppState } from '@/AppState.js';
import { vaultKeepService } from '@/services/vaultKeepService.js';
import Pop from '@/utils/Pop.js';
import { computed, ref } from 'vue';
import { logger } from '@/utils/Logger.js';
import { router } from '@/router.js';
import { Vault } from '@/models/Vault.js';
import { Modal } from 'bootstrap';

const keep = computed(() => AppState.keepById)

// const props = defineProps({
//   vaultProp: { type: Vault, required: true }
// })
const vaultKeepData = ref({
  keepId: null,
  vaultId: null
})
async function createVaultKeep() {

  try {
    vaultKeepData.value.keepId = AppState.keepById.id;
    await vaultKeepService.createVaultKeep(vaultKeepData.value)
    logger.log(AppState.keepById.id)
    router.push({ name: 'VaultDetails', params: { vaultId: vaultKeepData.value.vaultId } })
    Modal.getOrCreateInstance('#keepModal').hide()
    vaultKeepData.value = {
      keepId: 0,
      vaultId: 0
    }
    Pop.success('Keep In Vault!')
  }
  catch (error) {
    Pop.error(error);
  }
}
const accountVaults = computed(() => AppState.accountVaults)
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



              <div class="dropdown">
                <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
                  aria-expanded="false">
                  {{ accountVaults.length }} Vaults
                </a>
                <ul class="dropdown-menu">


                  <select id="vaultData" v-model="vaultKeepData.vaultId" class="form-select "
                    aria-label="Choose A Restaurant" required>
                    <option selected value="0" disabled>Choose a Vault</option>
                    <option v-for="vault in accountVaults" :key="vault.id" :value="vault.id">
                      <!-- <VaultKeepCard :vault-prop="vault" /> -->
                      {{ vault.name }}
                    </option>
                  </select>
                  <!-- <option v-for="restaurant in restaurants" :key="restaurant.id" :value="restaurant.id">
                    {{ restaurant.name }}
                  </option> -->


                </ul>
              </div>

              <button @click="createVaultKeep()" class="btn btn-color btn-dark">Save</button>
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
