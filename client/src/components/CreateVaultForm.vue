<script setup>
import { vaultService } from '@/services/VaultService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';

const vaultData = ref({
  img: '',
  name: '',
  description: '',
  isPrivate: false
})



async function createVault() {
  try {
    await vaultService.createVault(vaultData.value)
    vaultData.value = {
      img: '',
      name: '',
      description: '',
      isPrivate: false
    }
    Modal.getOrCreateInstance('#createVaultModal').hide()
    Pop.success('Report submitted!')
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div class="modal fade" id="createVaultModal" tabindex="-1" aria-labelledby="createVaultModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="createVaultModalLabel">Add Vault</h1>
        </div>
        <div class="modal-body">
          <form class="container-fluid" @submit.prevent="createVault()">
            <section class="row">

              <div class="mb-3">
                <label for="name" class="form-label">Vault Name</label>
                <input v-model="vaultData.name" type="text" class="form-control" id="name" aria-describedby="nameVault"
                  required maxlength="255">
                <div id="nameVault" class="form-text">Name Your Vault</div>
              </div>
              <div class="col-12 mb-3">
                <label for="vault-image-url">Image Url</label>
                <input v-model="vaultData.img" class="form-control" type="url" name="vault-image-url"
                  id="keep-image-url" required maxlength="1000">
              </div>
              <div class="mb-3">
                <label for="description" class="form-label">Description</label>
                <input v-model="vaultData.description" type="text" class="form-control" id="description"
                  aria-describedby="descriptionPeek" required maxlength="255">
                <div id="descriptionKeep" class="form-text">Description Of Vault</div>
              </div>
              <div class="mb-3 form-check">
                <input v-model="vaultData.isPrivate" type="checkbox" class="form-check-input" id="isPrivate">
                <label class="form-check-label" for="isPrivate">Private</label>
              </div>
              <div class="col-12 text-center">
                <img v-if="vaultData.img" :src="vaultData.img" class="img-preview" alt="could not load image">
              </div>
              <div class="col-12 text-end">
                <button class="btn btn-primary m-2"><i class="mdi mdi-plus"></i>Submit</button>
              </div>
            </section>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>
