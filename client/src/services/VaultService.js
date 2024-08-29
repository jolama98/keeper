import { Vault } from "@/models/Vault.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";

class VaultService {
  async getVaultKeeps(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}/keeps`)
    console.log("😂😂😂😂😂", response.data);
  }
  setActiveVault(vault) {
    AppState.activeVaults = vault
  }
  async destroyVault(vaultId) {
    const response = await api.delete(`api/vaults/${vaultId}`)
    const vaultDelete = AppState.keeps.findIndex(vaultToDelete => vaultToDelete.id == vaultId)
    AppState.vaults.splice(vaultDelete, 1)
  }
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    const newVault = new Vault(response.data)
    AppState.profileVaults.push(newVault)
  }
}

export const vaultService = new VaultService();
