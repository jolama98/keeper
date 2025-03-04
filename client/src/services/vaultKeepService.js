import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";


class VaultKeepService {
  async removeKeepFormVault(vaultKeepId) {
    const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    logger.log("REMOVED EEP FORM VAULT", response.data)
    const keepIndex = AppState.vaultKeeps.findIndex(vaultKeep => vaultKeep.vaultKeepId == vaultKeepId)
    if (keepIndex == -1) throw new Error("You messed up the findIndex, dawg")
    AppState.vaultKeeps.splice(keepIndex, 1)

    // const cultistIndex = AppState.cultists.findIndex(cultist => cultist.cultMemberId == cultMemberId)
    // if (cultistIndex == -1) throw new Error("You messed up the findIndex, dawg")
    // AppState.cultists.splice(cultistIndex, 1)
  }

  async createVaultKeep(createVaultKeepData) {
    const response = await api.post('api/vaultkeeps', createVaultKeepData)
    logger.log(response.data)
    // const vaultKeep = new VaultKeep(response.data)
    // AppState.vaultKeeps.push(vaultKeep)
  }
}

export const vaultKeepService = new VaultKeepService;
