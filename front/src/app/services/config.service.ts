import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { validateEnvironment } from '../../environments/environment.config';

// ===== CONFIGURATION SERVICE (Single Responsibility) =====
@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private readonly config = environment;

  constructor() {
    // Validar configuración al inicializar
    if (!validateEnvironment(this.config)) {
      console.error('❌ Environment configuration is invalid!');
      throw new Error('Invalid environment configuration');
    }
    
    // Log de configuración en desarrollo
    if (!this.config.production) {
      this.logConfiguration();
    }
  }

  // ===== API CONFIGURATION =====
  getApiUrl(): string {
    return this.config.apiUrl;
  }

  getApiBaseUrl(): string {
    // Extraer la URL base de la URL del episodio
    const episodeUrl = this.config.apiUrl;
    const baseUrl = episodeUrl.replace('/api/base/episode', '/api');
    return baseUrl;
  }
 
  // ===== APP CONFIGURATION =====
  getAppName(): string {
    return this.config.appName;
  }

  getVersion(): string {
    return this.config.version;
  }

  isProduction(): boolean {
    return this.config.production;
  }

  // ===== ENVIRONMENT INFO =====
  getEnvironmentInfo(): string {
    return `${this.getAppName()} v${this.getVersion()} - ${this.isProduction() ? 'Production' : 'Development'}`;
  }

  // ===== API ENDPOINTS =====
  getEpisodeEndpoint(): string {
    return this.getApiUrl();
  }
 
  // ===== DEBUGGING =====
  logConfiguration(): void {
    console.group('🔧 Application Configuration');
    console.log('App Name:', this.getAppName());
    console.log('Version:', this.getVersion());
    console.log('Environment:', this.isProduction() ? 'Production' : 'Development');
    console.log('API URL:', this.getApiUrl()); 
    console.groupEnd();
  }
}
