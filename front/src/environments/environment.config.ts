// ===== ENVIRONMENT CONFIGURATION =====
// Este archivo se usa para configuración adicional de environments
// Angular maneja automáticamente la selección de environment.ts vs environment.prod.ts

export interface EnvironmentConfig {
  production: boolean;
  apiUrl: string; 
  appName: string;
  version: string;
}

// ===== ENVIRONMENT VALIDATION =====
export function validateEnvironment(env: EnvironmentConfig): boolean {
  const requiredFields: (keyof EnvironmentConfig)[] = [
    'production',
    'apiUrl', 
    'appName',
    'version'
  ];

  return requiredFields.every(field => env[field] !== undefined && env[field] !== null);
}
