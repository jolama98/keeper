import { Vault } from "@/models/Vault.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";

class VaultService {
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    const newVault = new Vault(response.data)
    AppState.profileVaults.push(newVault)
  }
}

export const vaultService = new VaultService();
