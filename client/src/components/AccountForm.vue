<script setup>
import { onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { accountService } from '../services/AccountService.js';
import { AppState } from '@/AppState.js';
onMounted(() => { editableAccountData.value = { ...AppState.account } })

const editableAccountData = ref({
  name: '',
  picture: '',
  coverImg: '',
  email: '',

})

async function updateAccount() {
  try {
    await accountService.updateAccount(editableAccountData.value)
  } catch (error) {
    Pop.error(error)
  }
}

</script>


<template>
  <form @submit.prevent="updateAccount()">
    <div class="mb-3">
      <label for="name" class="form-label">Account Name</label>
      <input v-model="editableAccountData.name" type="text" class="form-control" id="name" required maxlength="100">
    </div>
    <div class="mb-3">
      <label for="picture" class="form-label">Account Picture</label>
      <input v-model="editableAccountData.picture" type="url" class="form-control" id="picture" required
        maxlength="500">
    </div>
    <div class="mb-3">
      <label for="coverImage" class="form-label">Cover Image</label>
      <input v-model="editableAccountData.coverImg" type="url" class="form-control" id="coverImage" maxlength="500">
    </div>
    <div class="mb-3">
      <label for="email" class="form-label">Email</label>
      <input v-model="editableAccountData.email" type="email" class="form-control" id="email" required maxlength="100">
    </div>
    <button type="submit" class="btn btn-success text-light">Submit</button>
  </form>
</template>


<style lang="scss" scoped></style>
