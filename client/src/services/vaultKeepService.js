import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepService {
  async createVaultKeep(createVaultKeepData) {
    const response = await api.post('api/vaultkeeps', createVaultKeepData)
    logger.log(response.data)
  }
}

export const vaultKeepService = new VaultKeepService;
